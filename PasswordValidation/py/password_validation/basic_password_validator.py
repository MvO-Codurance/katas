def validate(password: str):
    if len(password) < 9:
        return False

    if not any(character.isupper() for character in password):
        return False

    if not any(character.islower() for character in password):
        return False

    if not any(character.isdigit() for character in password):
        return False

    if not password.__contains__('_'):
        return False

    return True
