class ValidationException(Exception):
    ErrorCodes = []
    def __init__(self, errorCodes):
        self.ErrorCodes = errorCodes
