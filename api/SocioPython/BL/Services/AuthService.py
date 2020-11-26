from DAL.SocioContext import SocioContext
from BL.Validation.ValidationException import ValidationException
from flask_jwt_extended import create_access_token
import datetime

class AuthService(object):
    USER_ROLE = 'User'
    ADMIN_ROLE = 'Admin'
    db_context = None
    error_codes = None

    def __init__(self, db_context, error_codes):
        self.db_context = db_context
        self.error_codes = error_codes

    def token(self, login, password):
        result = self.db_context.exec_param_sproc(self.db_context.USER_LOGIN, [("Login", login), ("Password", password)])

        if len(result) == 0:
            raise ValidationException([self.error_codes.InvalidPassword])

        user = result[0]
        
        payload = {}
        payload["name"] = login
        payload["id"] = user["Id"]

        tokenString = create_access_token(payload, expires_delta = datetime.timedelta(days=14))
        tokenObj = {}
        tokenObj["access_token"] = tokenString
        tokenObj["role"] = user["Role"]

        return tokenObj
        
