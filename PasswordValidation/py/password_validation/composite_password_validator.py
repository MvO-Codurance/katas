from password_validation.flexible_password_validator import PasswordValidator


class CompositePasswordValidator(PasswordValidator):
    def __init__(self, validators: list):
        self.__validators = validators

    def validate(self, password: str) -> bool:
        for validator in self.__validators:
            if not validator.validate(password):
                return False
        return True
