import XCTest

class AuthenticatorTest: XCTestCase {

    override func setUp() {
        super.setUp()
    }

    override func tearDown() {
        super.tearDown()
    }

    func testAdministratorIsAlwaysAuthenticated() {
        let service = AuthenticationService()
        let adminId = 12345
        XCTAssertTrue(service.isAuthenticated(adminId))
    }

    func testNormalUserIsNotAuthenticatedInitially() {
        let service = AuthenticationService()
        let adminId = 11111
        XCTAssertFalse(service.isAuthenticated(adminId))
    }
    
}
