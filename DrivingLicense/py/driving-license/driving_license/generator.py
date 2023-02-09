from driving_license.driving_license_data import DrivingLicenseData

class DrivingLicenseGenerator():

    def generate(self, data: list) -> str:
        model = DrivingLicenseData(data)
        return self.format_surname(model)

    def format_surname(self, model: DrivingLicenseData) -> str:
        return model.surname.upper().ljust(5, '9')