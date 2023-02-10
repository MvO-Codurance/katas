
from datetime import datetime


class DrivingLicenseData:
    def __init__(self, data: list):
        self.forename: str = data[0]
        self.middle_name: str = data[1]
        self.surname: str = data[2]
        self.date_of_birth: datetime = datetime.strptime(data[3], '%d-%b-%Y')
        self.gender: str = data[4]