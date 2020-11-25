from flask import Flask, json, Response
from flask_jwt_extended import JWTManager
import datetime
import decimal
from flask_cors import CORS

from BL.Validation.ErrorCodes import ErrorCodes
from BL.Validation.ValidationException import ValidationException

from DAL.SocioContext import SocioContext

from BL.Services.AuthService import AuthService
from BL.Services.ProfileService import ProfileService

from WEB.Controllers.AuthController import AuthController
from WEB.Controllers.ProfileController import ProfileController


class FlaskApp(object):
    app = None
    jwt = None
    
    auth_controller = None
    profile_controller = None

    db_context = None

    auth_service = None
    profile_service = None

    def __init__(self):
        self.app = Flask(__name__, static_folder=None)        
        CORS(self.app)
        self.app.config['JWT_SECRET_KEY'] = "YLU]o:qifk]Z17{H'l2hIC?7_YbQ]"
        self.jwt = JWTManager(self.app)
        json.JSONEncoder.default = self.__json_types_handler
        
        self.__create_error_handlers()
        self.__create_dependencies()
        self.__create_controllers()
        self.__register_blueprints()

    def run(self, host, port):
        self.app.run(host, port, threaded=True)

    def __register_blueprints(self):
        self.app.register_blueprint(self.auth_controller.get_blueprint())
        self.app.register_blueprint(self.profile_controller.get_blueprint())

    def __create_dependencies(self):
        self.db_context = SocioContext()
        self.error_codes = ErrorCodes()

        self.auth_service = AuthService(self.db_context, self.error_codes)
        self.profile_service = ProfileService(self.db_context)

    def __create_controllers(self):
        self.auth_controller = AuthController(__name__, self.auth_service)
        self.profile_controller = ProfileController(__name__, self.profile_service)


    def __create_error_handlers(self):
        self.app.register_error_handler(ValidationException, self.__validation_exception_handler)
        self.app.register_error_handler(Exception, self.__global_exception_handler)

    def __json_types_handler(self, x):
        if isinstance(x, datetime.datetime):
            return x.isoformat()
        if isinstance(x, decimal.Decimal):
            return str(x)
        raise TypeError("Unknown type")

    def __validation_exception_handler(self, e):
        print(e)
        resp = Response(status=400, content_type="application/json")
        data = json.dumps(e.__dict__)
        resp.set_data(data)
        return resp

    def __global_exception_handler(self, e):
        print(e)
        resp = Response(status=500, content_type="application/json")
        data = json.dumps({})
        resp.set_data(data)
        return resp


if __name__ == "__main__":
    import os
    HOST = os.environ.get("SERVER_HOST")
    PORT = int(os.environ.get("SERVER_PORT"))

    app = FlaskApp()

    app.run(HOST, PORT)