from flask import Blueprint, jsonify, request

from flask_jwt_extended import get_jwt_identity, jwt_required

from WEB.Helpers.token_validation_helper import user_role_validator

class ProfileController(object):
    profiles_blueprint = None
    profile_service = None
    
    def __init__(self, name, profile_service):
        self.profile_service = profile_service
        self.profiles_blueprint = Blueprint("profile_controller", name, url_prefix = "")

        #url identifier method-name request-type
        self.profiles_blueprint.add_url_rule("/api/ProfileNew", "sign_up", self.__sign_up, methods=["POST"])
        self.profiles_blueprint.add_url_rule("/api/ProfileNew", "edit_profile", self.__edit_profile, methods=["PUT"])
        self.profiles_blueprint.add_url_rule("/api/ProfileNew/ByLogin/<login>", "by_login", self.__by_login, methods=["GET"])
        self.profiles_blueprint.add_url_rule("/api/ProfileNew/IsBanned/<login>", "is_banned", self.__is_banned, methods=["GET"])
        self.profiles_blueprint.add_url_rule("/api/ProfileNew/EditPassword/<newPassword>", "edit_password", self.__edit_password, methods=["GET"])
        self.profiles_blueprint.add_url_rule("/api/ProfileNew/BanUser/<id>", "ban_user", self.__ban_user, methods=["GET"])
        self.profiles_blueprint.add_url_rule("/api/ProfileNew/", "get_all", self.__get_all, methods=["GET"])
        self.profiles_blueprint.add_url_rule("/api/MessageNew", "post_message", self.__post_message, methods=["POST"])
        self.profiles_blueprint.add_url_rule("/api/ConversationNew/ByUser/<id>", "get_conversation", self.__get_conversation, methods=["GET"])
        self.profiles_blueprint.add_url_rule("/api/ConversationNew/LatestByUser", "latest_by_user", self.__latest_by_user, methods=["GET"])
        self.profiles_blueprint.add_url_rule("/api/FeedMessageNew/ByUser/<id>", "get_feeds", self.__get_feeds, methods=["GET"])
        self.profiles_blueprint.add_url_rule("/api/FeedMessageNew", "create_feed", self.__create_feed, methods=["POST"])
        self.profiles_blueprint.add_url_rule("/api/FeedMessageNew", "edit_feed", self.__edit_feed, methods=["PUT"])
        self.profiles_blueprint.add_url_rule("/api/FeedMessageNew/<id>", "delete_feed", self.__delete_feed, methods=["DELETE"])

    def get_blueprint(self):
        return self.profiles_blueprint


    def __sign_up(self):
        jsonObj = request.get_json(silent = True)        
        return jsonify(self.profile_service.sign_up(jsonObj)) 

    def __edit_profile(self):
        # if POST jsonObj -> body
        jsonObj = request.get_json(silent = True)
        return jsonify(self.profile_service.edit_profile(jsonObj))

    def __by_login(self, login):
        data = self.profile_service.get_info_by_login(login)
        return jsonify(data)

    def __is_banned(self, login):
        data = self.profile_service.is_banned(login)
        return jsonify(data)

    #[Authorize] analog
    @jwt_required
    def __edit_password(self, newPassword):
        id = get_jwt_identity()["id"] # GetCurrentUserId
        self.profile_service.edit_password(newPassword, id)
        return 'Ok'
        
    def __ban_user(self, id):
        self.profile_service.ban_user(id)
        return 'Ok'

    def __get_all(self):
        data = self.profile_service.get_all()
        return jsonify(data)

    @jwt_required
    def __post_message(self):        
        jsonObj = request.get_json(silent = True)   
        id = get_jwt_identity()["id"]
        return jsonify(self.profile_service.post_message(jsonObj, id))

    @jwt_required
    def __get_conversation(self, id):
        userId = get_jwt_identity()["id"]
        return jsonify(self.profile_service.get_conversation(userId, id))

    @jwt_required
    def __latest_by_user(self):
        userId = get_jwt_identity()["id"]
        return jsonify(self.profile_service.latest_by_user(userId))

    def __get_feeds(self, id):
        return jsonify(self.profile_service.get_feeds(id))

    @jwt_required
    def __create_feed(self):
        userId = get_jwt_identity()["id"]
        jsonObj = request.get_json(silent = True)
        return jsonify(self.profile_service.create_feed(jsonObj, userId))

    def __edit_feed(self):
        jsonObj = request.get_json(silent = True)
        return jsonify(self.profile_service.edit_feed(jsonObj))

    def __delete_feed(self, id):
        self.profile_service.delete_feed(id)
        return 'Ok'