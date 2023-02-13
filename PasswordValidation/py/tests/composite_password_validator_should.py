from password_validation.composite_password_validator import CompositePasswordValidator
from tests.always_true_password_validator import AlwaysTruePasswordValidator


def test_return_true_when_using_the_always_true_validator():
    validators = [AlwaysTruePasswordValidator()]
    assert CompositePasswordValidator(validators).validate("Password_1") is True
