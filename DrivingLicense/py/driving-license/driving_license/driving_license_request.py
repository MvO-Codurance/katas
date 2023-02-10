from pydantic.main import BaseModel

class DrivingLicenseRequestModel(BaseModel):
    forename: str
    middle_name: str
    surname: str
    date_of_birth: str
    gender: str