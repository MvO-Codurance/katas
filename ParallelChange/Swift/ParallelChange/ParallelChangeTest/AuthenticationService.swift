import XCTest

class AuthenticationService {

    //
    // the goal is to replace the method above with this one:
    // func isAuthenticated(role, userId)
    //

    func isAuthenticated(userId: Int) -> Bool {
        return userId == 12345
    }
}

class AuthenticationClient {
    let authenticationService: AuthenticationService

    init(authenticationService: AuthenticationService) {
        self.authenticationService = authenticationService
    }

    func run() {
        let authenticated = authenticationService.isAuthenticated(33)
        print("authenticated: \(authenticated)")
    }
}

class YetAnotherClient {
    func run() {
        AuthenticationService().isAuthenticated(100)
    }
}

class AuthenticationServiceMain: XCTestCase {
    func runExample() {
        let client = AuthenticationClient(authenticationService: AuthenticationService())
        client.run()
    }

    func testRunExample() {
        runExample()
    }
}
