import pytest

from password_validation.flexible_password_validator import LengthPasswordValidator, UppercasePasswordValidator, \
    LowercasePasswordValidator, NumberPasswordValidator, UnderscorePasswordValidator


@pytest.mark.parametrize('password, minimum_length, expected', [
    pytest.param("123456", 9, False),
    pytest.param("123456789", 9, True),
    pytest.param("1234567890", 9, True)
])
def test_correctly_validate_minimum_length(
        password: str,
        minimum_length: int,
        expected: bool):
    assert LengthPasswordValidator(minimum_length).validate(password) == expected


@pytest.mark.parametrize('password, expected', [
    pytest.param("123456", False),
    pytest.param("password", False),
    pytest.param("Password", True),
    pytest.param("PASSWORD", True)
])
def test_correctly_validate_uppercase(
        password: str,
        expected: bool):
    assert UppercasePasswordValidator().validate(password) == expected


@pytest.mark.parametrize('password, expected', [
    pytest.param("123456", False),
    pytest.param("PASSWORD", False),
    pytest.param("PASSWORd", True),
    pytest.param("password", True)
])
def test_correctly_validate_lowercase(
        password: str,
        expected: bool):
    assert LowercasePasswordValidator().validate(password) == expected


@pytest.mark.parametrize('password, expected', [
    pytest.param("password", False),
    pytest.param("_sdfPP_", False),
    pytest.param("1password", True),
    pytest.param("123456", True)
])
def test_correctly_validate_number(
        password: str,
        expected: bool):
    assert NumberPasswordValidator().validate(password) == expected


@pytest.mark.parametrize('password, expected', [
    pytest.param("password", False),
    pytest.param("PASSWORD", False),
    pytest.param("1_password", True),
    pytest.param("_____", True)
])
def test_correctly_validate_underscore(
        password: str,
        expected: bool):
    assert UnderscorePasswordValidator().validate(password) == expected
