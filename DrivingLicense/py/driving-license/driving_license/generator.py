from driving_license.driving_license_data import DrivingLicenseData

class DrivingLicenseGenerator():

    def generate(self, data: list) -> str:
        model = DrivingLicenseData(data)
        return f"{self.__format_surname(model)}" \
            f"{self.__format_birth_year_decade(model)}"

    def __format_surname(self, model: DrivingLicenseData) -> str:
        return model.surname.upper()[:5].ljust(5, '9')

    def __format_birth_year_decade(self, model: DrivingLicenseData) -> str:
        return str(model.date_of_birth.year)[-2]