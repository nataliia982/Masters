import pypyodbc

pypyodbc.lowercase = False

class SocioContext(object):    
    BAN_USER = "[dbo].[BanUser]"
    CHECK_EMAIL = "[dbo].[CheckEmail]"
    CHECK_LOGIN = "[dbo].[CheckLogin]"
    CREATING_CONVERSATION = "[dbo].[CreatingConversation]"
    DELETE_FEED = "[dbo].[DeleteFeed]"
    EDIT_PASSWORD = "[dbo].[EditPassword]"
    GET_ALL_USERS = "[dbo].[GetAllUsers]"
    GET_BY_LOGIN = "[dbo].[GetByLogin]"
    GET_CON_MESSAGES = "[dbo].[GetConMessages]"
    GET_CONVERSATION = "[dbo].[GetConversation]"
    GET_CONVERSATIONS = "[dbo].[GetConversations]"
    GET_FEEDS = "[dbo].[GetFeeds]"
    IS_BANNED = "[dbo].[IsBanned]"
    POST_FEED = "[dbo].[PostFeed]"
    POST_MESSAGE = "[dbo].[PostMessage]"
    UPDATE_FEED = "[dbo].[UpdateFeed]"
    UPDATE_USER = "[dbo].[UpdateUser]"
    USER_LOGIN = "[dbo].[UserLogin]"
    USER_SIGN_UP = "[dbo].[UserSignUp]"
    GET_USER_INFO_SIGN_UP = "[dbo].[GetUserInfoSignUp]"
    LAST_CONV_MESSAGE = "[dbo].[LastConvMessage]"
    LAST_FEED_MESSAGE = "[dbo].[LastFeedMessage]"
    SEPARATOR = ","

    def exec_no_param_sproc(self, sproc_name):
        return self.__exec_sproc(sproc_name)

    def exec_param_sproc(self, sproc_name, params):
        return self.__exec_sproc(sproc_name, params)

    def __connect(self):        
        connection = pypyodbc.connect("Driver={ODBC Driver 13 for SQL Server};Server=(LocalDb)\MSSQLLocalDB;Database=Socio;Trusted_Connection=Yes;")
        return connection.cursor()

    def __construct_command(self, sproc_name, params = None):
        sql_command = "exec " + sproc_name
        if params:
            param_strings = []
            for param in params:
                if isinstance(param[1], str):
                    param_strings.append("@" + param[0] + " = N'" + str(param[1]) + "'")
                elif param[1] is None:
                    continue
                else:
                    param_strings.append("@" + param[0] + " = " + str(param[1]))
            sql_command += self.SEPARATOR.join(param_strings)
        return sql_command

    def __read_results(self, cursor):
        query_results = []
        if cursor.description:
            columns = [column[0] for column in cursor.description]
            query_row = cursor.fetchone()
            while query_row:
                query_results.append(dict(zip(columns, query_row)))
                query_row = cursor.fetchone()
        return query_results

    def __disconnect(self, cursor):
        connection = cursor.connection
        connection.commit()
        connection.close()

    def __exec_sproc(self, sproc_name, params=None):
        cursor = self.__connect()
        sql_command = self.__construct_command(sproc_name, params)
        cursor.execute(sql_command)
        query_results = self.__read_results(cursor)
        self.__disconnect(cursor)
        return query_results
