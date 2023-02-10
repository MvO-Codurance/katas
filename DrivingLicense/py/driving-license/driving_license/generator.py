from driving_license.driving_license_data import DrivingLicenseData

class DrivingLicenseGenerator():

    def generate(self, data: list) -> str:
        model = DrivingLicenseData(data)
        return f"{self.__format_surname(model)}" \
            f"{self.__format_birth_year_decade(model)}" \
            f"{self.__format_birth_month(model)}" \
            f"{self.__format_birth_day_of_month(model)}"

    def __format_surname(self, model: DrivingLicenseData) -> str:
        return model.surname.upper()[:5].ljust(5, '9')

    def __format_birth_year_decade(self, model: DrivingLicenseData) -> str:
        return str(model.date_of_birth.year)[-2]

    def __format_birth_month(self, model: DrivingLicenseData) -> str:
        month = model.date_of_birth.month
        if model.gender == 'F':
            month += 50
        return str(month).rjust(2, '0')

    def __format_birth_day_of_month(self, model: DrivingLicenseData) -> str:
        return str(model.date_of_birth.day).rjust(2, '0')

