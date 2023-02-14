import pytest

from password_validation.composite_password_validator import CompositePasswordValidator
from password_validation.flexible_password_validator import LengthPasswordValidator, UppercasePasswordValidator, \
    LowercasePasswordValidator, NumberPasswordValidator, UnderscorePasswordValidator
from password_validation.password_validator_builder import PasswordValidatorBuilder
from tests.always_true_password_validator import AlwaysTruePasswordValidator


def test_return_a_composite_password_validator_from_build():
    assert isinstance(PasswordValidatorBuilder().build(), CompositePasswordValidator)


def test_return_the_password_validator_builder_from_add():
    builder = PasswordValidatorBuilder()
    assert builder.add(AlwaysTruePasswordValidator()) is builder


@pytest.mark.parametrize('password, expected, reason', [
    pytest.param('Ab1_xxxxx', True, 'is >= 9 characters, has uppercase, has lowercase, has number, has underscore'),
    pytest.param('Ab1_', False, 'password is < 9 characters in length'),
    pytest.param('ab1_xxxxx', False, 'password does not contain an uppercase character'),
    pytest.param('AB1_XXXXX', False, 'password does not contain an lowercase character'),
    pytest.param('Abc_xxxxx', False, 'password does not contain a number character'),
    pytest.param('Ab1-xxxxx', False, 'password does not contain an underscore character')
])
def test_build_a_validator_to_correctly_validate_iteration1_passwords(
        password: str,
        expected: bool,
        reason: str):
    validator = PasswordValidatorBuilder() \
        .add(LengthPasswordValidator(9)) \
        .add(UppercasePasswordValidator()) \
        .add(LowercasePasswordValidator()) \
        .add(NumberPasswordValidator()) \
        .add(UnderscorePasswordValidator()) \
        .build()

    assert validator.validate(password) == expected, reason


@pytest.mark.parametrize('password, expected, reason', [
    pytest.param('Ab1_xxx', True, 'is >= 7 characters, has uppercase, has lowercase, has number'),
    pytest.param('Ab1_', False, 'password is < 7 characters in length'),
    pytest.param('ab1_xxx', False, 'password does not contain an uppercase character'),
    pytest.param('AB1_XXX', False, 'password does not contain an lowercase character'),
    pytest.param('Abc_xxx', False, 'password does not contain a number character')
])
def test_build_a_validator_to_correctly_validate_iteration2a_passwords(
        password: str,
        expected: bool,
        reason: str):
    validator = PasswordValidatorBuilder() \
        .add(LengthPasswordValidator(7)) \
        .add(UppercasePasswordValidator()) \
        .add(LowercasePasswordValidator()) \
        .add(NumberPasswordValidator()) \
        .build()

    assert validator.validate(password) == expected, reason


@pytest.mark.parametrize('password, expected, reason', [
    pytest.param('Ab1_xxxxxxxxxxxxx', True, 'is >= 17 characters, has uppercase, has lowercase, has underscore'),
    pytest.param('Ab1_', False, 'password is < 17 characters'),
    pytest.param('ab1_xxxxxxxxxxxxx', False, 'password does not contain an uppercase character'),
    pytest.param('AB1_XXXXXXXXXXXXX', False, 'password does not contain an lowercase character'),
    pytest.param('Ab1-XXXXXXXXXXXXX', False, 'password does not contain an underscore character')
])
def test_build_a_validator_to_correctly_validate_iteration2b_passwords(
        password: str,
        expected: bool,
        reason: str):
    validator = PasswordValidatorBuilder() \
        .add(LengthPasswordValidator(17)) \
        .add(UppercasePasswordValidator()) \
        .add(LowercasePasswordValidator()) \
        .add(UnderscorePasswordValidator()) \
        .build()

    assert validator.validate(password) == expected, reason
