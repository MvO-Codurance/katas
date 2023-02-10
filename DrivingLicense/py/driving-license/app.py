from driving_license.driving_license_request import DrivingLicenseRequestModel
from driving_license.generator import DrivingLicenseGenerator
from fastapi import FastAPI

driving_license_app = FastAPI()


@driving_license_app.get("/")
def read_root():
    return {"Hello": "World"}


@driving_license_app.post("/license")
def generate_license(request: DrivingLicenseRequestModel) -> dict[str, str]:
    data = list(request.dict().values())
    return {"license": DrivingLicenseGenerator().generate(data=data)}