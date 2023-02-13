import pytest

from password_validation.basic_password_validator import validate


@pytest.mark.parametrize('password, expected, reason', [
    pytest.param("Password", False, 'is < 9 characters'),
    pytest.param("password_1", False, 'does not have uppercase'),
    pytest.param("PASSWORD_1", False, 'does not have lowercase'),
    pytest.param("Password_x", False, 'does not have number'),
    pytest.param("Password12", False, 'does not have underscore'),
    pytest.param("Password_1", True, 'is > 8  characters, has uppercase, has lowercase, has number, has underscore')
])
def test_correctly_validate_passwords(
        password: str,
        expected: bool,
        reason: str):
    assert validate(password) == expected, reason
