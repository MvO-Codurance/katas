from password_validation.flexible_password_validator import PasswordValidator


class AlwaysTruePasswordValidator(PasswordValidator):
    def validate(self, password: str) -> bool:
        return True
