import pytest

from driving_license.generator import DrivingLicenseGenerator

data1 = ["John", "James", "Smith", "01-Jan-2000", "M"]
data2 = ["Jonny", "Jimmy", "Smithson", "01-Jan-2000", "M"]
data3 = ["Johanna", "", "Gibbs", "13-Dec-1981", "F"]
data4 = ["Dave", "", "Doh", "13-Nov-1976", "M"]


@pytest.mark.parametrize('data, expected', [
    pytest.param(data1, 'SMITH'),
    pytest.param(data2, 'SMITH'),
    pytest.param(data3, 'GIBBS'),
    pytest.param(data4, 'DOH99')
])
def test_should_return_chars_1_to_5_from_surname_right_padded_with_9s(
    data: list,
    expected: str
):
    actual = DrivingLicenseGenerator().generate(data)
    assert actual[:5] == expected


@pytest.mark.parametrize('data, expected', [
    pytest.param(data1, '0'),
    pytest.param(data2, '0'),
    pytest.param(data3, '8'),
    pytest.param(data4, '7')
])
def test_should_return_char_6_as_decade_digit_from_year_of_birth(
    data: list,
    expected: str
):
    actual = DrivingLicenseGenerator().generate(data)
    assert actual[5] == expected