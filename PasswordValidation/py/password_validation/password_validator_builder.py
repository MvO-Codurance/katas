from password_validation.composite_password_validator import CompositePasswordValidator
from password_validation.flexible_password_validator import PasswordValidator


class PasswordValidatorBuilder:
    def __init__(self):
        self.__validators: list = []

    def add(self, validator: PasswordValidator):
        self.__validators.append(validator)
        return self

    def build(self):
        return CompositePasswordValidator(self.__validators)
