import pytest

from password_validation.composite_password_validator import CompositePasswordValidator
from password_validation.flexible_password_validator import LengthPasswordValidator, UppercasePasswordValidator, \
    LowercasePasswordValidator, NumberPasswordValidator, UnderscorePasswordValidator
from password_validation.password_validator_builder import PasswordValidatorBuilder
from tests.always_true_password_validator import AlwaysTruePasswordValidator


#def test_return_a_composite_password_validator_from_build():
#    assert isinstance(PasswordValidatorBuilder().build(), CompositePasswordValidator)


#def test_return_the_password_validator_builder_from_add():
#    builder = PasswordValidatorBuilder()
#    assert builder.add(AlwaysTruePasswordValidator) == builder


@pytest.mark.parametrize('password, expected, reason', [
    pytest.param('Ab1_xxxxx', True, 'is >= 9 characters, has uppercase, has lowercase, has number, has underscore')
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
