import pytest

from driving_license.generator import DrivingLicenseGenerator


@pytest.mark.parametrize('data, expected', [
    pytest.param(["John", "James", "Smith", "01-Jan-2000", "M"], 'SMITH'),
    pytest.param(["Jonny", "Jimmy", "Smithson", "01-Jan-2000", "M"], 'SMITH'),
    pytest.param(["Johanna", "", "Gibbs", "13-Dec-1981", "F"], 'GIBBS'),
    pytest.param(["Dave", "", "Doh", "13-Nov-1976", "M"], 'DOH99')
])
def test_should_first_five_chars_is_surname_right_padded_with_9s(
    data: list,
    expected: str
):
    actual = DrivingLicenseGenerator().generate(data)
    assert actual[:5] == expected