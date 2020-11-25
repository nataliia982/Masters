from DAL.SocioContext import SocioContext
from BL.Validation.ValidationException import ValidationException
from BL.Validation.ErrorCodes import ErrorCodes

from flask import jsonify, json

class ProfileService(object):
    db_context = None

    def __init__(self, db_context):
        self.db_context = db_context

    def sign_up(self, jsonObj):
        # exec_param_sproc -> if params
        checkLogin = self.db_context.exec_param_sproc(self.db_context.CHECK_LOGIN, [("Login", jsonObj["login"])])
        
        if len(checkLogin) != 0:
            raise ValidationException([self.error_codes.LoginExist])

        checkEmail = self.db_context.exec_param_sproc(self.db_context.CHECK_EMAIL, [("Email", jsonObj["email"])])
        
        if len(checkEmail) != 0:
            raise ValidationException([self.error_codes.EmailExist])

        result = self.db_context.exec_param_sproc(self.db_context.USER_SIGN_UP, [("Name", jsonObj["name"]), ("Surname", jsonObj["surname"]), ("Phone", jsonObj["phone"]), ("City", jsonObj["city"]), ("Email", jsonObj["email"]), ("Login", jsonObj["login"]), ("Password", jsonObj["password"]), ("Role", "User"), ("IsBanned", 0), ("IsDeleted", 0)])

        res = self.db_context.exec_param_sproc(self.db_context.GET_USER_INFO_SIGN_UP, [("Login", jsonObj["login"])])[0]

        return self.camelCaseObj(res)

    def get_info_by_login(self, login):
        res = self.db_context.exec_param_sproc(self.db_context.GET_BY_LOGIN, [("Login", login)])[0]
        return self.camelCaseObj(res) 

    def is_banned(self, login):
        res = self.db_context.exec_param_sproc(self.db_context.IS_BANNED, [("Login", login)])[0]
        return self.camelCaseObj(res)

    def ban_user(self, id):
        self.db_context.exec_param_sproc(self.db_context.BAN_USER, [("UserId", id)])
        return 

    def edit_password(self, newPassword, id):
        self.db_context.exec_param_sproc(self.db_context.EDIT_PASSWORD, [("UserId", id), ("Password", newPassword)])
        return

    def edit_profile(self, jsonObj):
        self.db_context.exec_param_sproc(self.db_context.UPDATE_USER, [("UserId", jsonObj["id"]), ("Name", jsonObj["name"]), ("Surname", jsonObj["surname"]), ("Phone", jsonObj["phone"]), ("Position", jsonObj["position"]), ("City", jsonObj["city"]), ("WebsiteLink", jsonObj["websiteLink"]), ("FacebookLink", jsonObj["facebookLink"]), ("TwitterLink", jsonObj["twitterLink"])])
        return

    def get_all(self):
        # exec_no_param_sproc -> if no params
        res = self.db_context.exec_no_param_sproc(self.db_context.GET_ALL_USERS)

        return self.camelCaseList(res)

    # !!!!
    def camelCaseList(self, list):
        res_lis = []

        for x in list:
            i = {k[:1].lower() + k[1:]: v for k, v in x.items()}
            res_lis.append(i)

        return res_lis

    # !!!!
    def camelCaseObj(self, obj):
        return {k[:1].lower() + k[1:]: v for k, v in obj.items()}

    def post_message(self, jsonObj, id):
        self.db_context.exec_param_sproc(self.db_context.POST_MESSAGE, [("UserId", id), ("ConversationId", jsonObj["conversationId"]), ("Body", jsonObj["body"]), ("IsDeleted", False)])
        
        res = self.db_context.exec_param_sproc(self.db_context.LAST_CONV_MESSAGE, [("UserId", id), ("ConversationId", jsonObj["conversationId"])])[0]

        return self.camelCaseObj(res)

    def get_conversation(self, userId, id):
        res = self.db_context.exec_param_sproc(self.db_context.GET_CONVERSATION, [("UserToId", userId), ("UserFromId", id)]) 

        if len(res) != 0: 
            messages = self.db_context.exec_param_sproc(self.db_context.GET_CON_MESSAGES, [("ConversationId", res[0]["ConversationEntity_Id"])]) 

            res_lis = self.camelCaseList(messages)

            result = {};
            result["conversationId"] = res[0]["ConversationEntity_Id"];
            result["messages"] = res_lis;
            return result

        else:
            creatId = self.db_context.exec_param_sproc(self.db_context.CREATING_CONVERSATION, [("IsDeleted", False), ("UserFromId", id), ("UserToId", userId)]) 
            convId = self.db_context.exec_param_sproc(self.db_context.GET_CONVERSATION, [("UserToId", userId), ("UserFromId", id)])[0]["ConversationEntity_Id"]
            result = {};
            result["conversationId"] = convId
            result["messages"] = []
            return result


    def latest_by_user(self, userId):
        res = self.db_context.exec_param_sproc(self.db_context.GET_CONVERSATIONS, [("UserId", userId)]) 
        return self.camelCaseList(res)

    def get_feeds(self, id): 
        res = self.db_context.exec_param_sproc(self.db_context.GET_FEEDS, [("UserId", id)])
        return self.camelCaseList(res)


    def create_feed(self, jsonObj, userId): 
        self.db_context.exec_param_sproc(self.db_context.POST_FEED, [("UserFromId", userId), ("UserToId", jsonObj["userId"]), ("WasEdited", False), ("IsDeleted", False), ("FeedText", jsonObj["feedText"])])
        res = self.db_context.exec_param_sproc(self.db_context.LAST_FEED_MESSAGE, [("UserId", jsonObj["userId"])])[0]
        
        return self.camelCaseObj(res)

    def delete_feed(self, id):
        self.db_context.exec_param_sproc(self.db_context.DELETE_FEED, [("FeedId", id)])
        return


    def edit_feed(self , jsonObj):
        self.db_context.exec_param_sproc(self.db_context.UPDATE_FEED, [("FeedId", jsonObj["id"]), ("FeedText", jsonObj["feedText"])])
        jsonObj["wasEdited"] = True
        return jsonObj