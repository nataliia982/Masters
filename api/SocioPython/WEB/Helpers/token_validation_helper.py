from functools import wraps
from flask_jwt_extended import jwt_required
from flask_jwt_extended.view_decorators import _decode_jwt_from_request
from flask_jwt_extended.exceptions import NoAuthorizationError

def user_role_validator(view_function):
    @wraps(view_function)
    def wrapper(*args, **kwargs):
        jwt_data = _decode_jwt_from_request(request_type='access')
        #role = jwt_data["identity"]["role"]
        #if role != "User":
        #    raise NoAuthorizationError("Not User role")
        return view_function(*args, **kwargs)
    return jwt_required(wrapper)

def admin_role_validator(view_function):
    @wraps(view_function)
    def wrapper(*args, **kwargs):
        jwt_data = _decode_jwt_from_request(request_type='access')
        #role = jwt_data["identity"]["role"]
        #if role != "Admin":
        #    raise NoAuthorizationError("Not Admin role")
        return view_function(*args, **kwargs)
    return jwt_required(wrapper)

def isLocked_validator(view_function):
    @wraps(view_function)
    def wrapper(*args, **kwargs):
        jwt_data = _decode_jwt_from_request(request_type='access')
        isLocked = jwt_data["identity"]["isLocked"]
        if isLocked:
            raise NoAuthorizationError("User is blocked")
        return view_function(*args, **kwargs)
    return jwt_required(wrapper)
