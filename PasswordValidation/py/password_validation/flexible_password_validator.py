from typing import Protocol


class PasswordValidator(Protocol):
    def validate(self, password: str) -> bool:
        pass


class LengthPasswordValidator(PasswordValidator):
    def __init__(self, minimum_length: int):
        self.minimum_length = minimum_length

    def validate(self, password: str) -> bool:
        return len(password) >= self.minimum_length


class UppercasePasswordValidator(PasswordValidator):
    def validate(self, password: str) -> bool:
        if not any(character.isupper() for character in password):
            return False
        return True


class LowercasePasswordValidator(PasswordValidator):
    def validate(self, password: str) -> bool:
        if not any(character.islower() for character in password):
            return False
        return True


class NumberPasswordValidator(PasswordValidator):
    def validate(self, password: str) -> bool:
        if not any(character.isdigit() for character in password):
            return False
        return True


class UnderscorePasswordValidator(PasswordValidator):
    def validate(self, password: str) -> bool:
        return password.__contains__('_')
