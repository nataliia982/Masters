from flask import Blueprint, jsonify, request
from flask_jwt_extended import get_jwt_identity, jwt_required

class AuthController(object):
    auth_blueprint = None
    auth_service = None

    def __init__(self, name, auth_service):
        self.auth_service = auth_service
        self.auth_blueprint = Blueprint("auth_controller", name, url_prefix = "")

        self.auth_blueprint.add_url_rule("/token", "token", self.__token, methods=["POST"])

    def get_blueprint(self):
        return self.auth_blueprint
    
    def __token(self):
        username = request.form.get("username")
        password = request.form.get("password")
        if not(username) or not(password):
            raise Exception
        data = self.auth_service.token(username, password)
        return jsonify(data)
