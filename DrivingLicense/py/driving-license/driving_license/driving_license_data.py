
class DrivingLicenseData:
    def __init__(self, data: list):
        self.forename: str = data[0]
        self.middle_name: str = data[1]
        self.surname: str = data[2]