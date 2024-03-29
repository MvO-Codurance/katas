import pytest

from driving_license.generator import DrivingLicenseGenerator

data1 = ["John", "James", "Smith", "01-Jan-2000", "M"]
data2 = ["Jonny", "Jimmy", "Smithson", "01-Jan-2000", "M"]
data3 = ["Johanna", "", "Gibbs", "13-Dec-1981", "F"]
data4 = ["Dave", "", "Doh", "13-Nov-1976", "M"]


@pytest.mark.parametrize('data, expected', [
    pytest.param(data1, 'SMITH001010JJ9AA'),
    pytest.param(data2, 'SMITH001010JJ9AA'),
    pytest.param(data3, 'GIBBS862131J99AA'),
    pytest.param(data4, 'DOH99711136D99AA')
])
def test_should_return_fully_generator_license_number(
    data: list,
    expected: str
):
    actual = DrivingLicenseGenerator().generate(data)
    assert actual == expected


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
def test_should_return_char_6_as_decade_digit_from_date_of_birth(
    data: list,
    expected: str
):
    actual = DrivingLicenseGenerator().generate(data)
    assert actual[5] == expected


@pytest.mark.parametrize('data, expected', [
    pytest.param(data1, '01'),
    pytest.param(data2, '01'),
    pytest.param(data3, '62'),
    pytest.param(data4, '11')
])
def test_should_return_chars_7_to_8_as_month_digits_from_date_of_birth(
    data: list,
    expected: str
):
    actual = DrivingLicenseGenerator().generate(data)
    assert actual[6:8] == expected


@pytest.mark.parametrize('data, expected', [
    pytest.param(data1, '01'),
    pytest.param(data2, '01'),
    pytest.param(data3, '13'),
    pytest.param(data4, '13')
])
def test_should_return_chars_9_to_10_as_day_of_month_digits_from_date_of_birth(
    data: list,
    expected: str
):
    actual = DrivingLicenseGenerator().generate(data)
    assert actual[8:10] == expected


@pytest.mark.parametrize('data, expected', [
    pytest.param(data1, '0'),
    pytest.param(data2, '0'),
    pytest.param(data3, '1'),
    pytest.param(data4, '6')
])
def test_should_return_char_11_as_year_digit_from_date_of_birth(
    data: list,
    expected: str
):
    actual = DrivingLicenseGenerator().generate(data)
    assert actual[10] == expected


@pytest.mark.parametrize('data, expected', [
    pytest.param(data1, 'JJ'),
    pytest.param(data2, 'JJ'),
    pytest.param(data3, 'J9'),
    pytest.param(data4, 'D9')
])
def test_should_return_chars_12_to_13_as_first_initial_of_firstname_and_middlename_or_9(
    data: list,
    expected: str
):
    actual = DrivingLicenseGenerator().generate(data)
    assert actual[11:13] == expected


@pytest.mark.parametrize('data, expected', [
    pytest.param(data1, '9AA'),
    pytest.param(data2, '9AA'),
    pytest.param(data3, '9AA'),
    pytest.param(data4, '9AA')
])
def test_should_return_chars_14_to_16_fixed_as_9AA(
    data: list,
    expected: str
):
    actual = DrivingLicenseGenerator().generate(data)
    assert actual[13:17] == expected