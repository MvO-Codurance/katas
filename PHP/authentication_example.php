<?php
declare(strict_types = 1);

use ParallelChange\AuthenticationService;

require __DIR__ . '/vendor/autoload.php';

class AuthenticationClient {
	private $authenticationService;

	public function __construct( AuthenticationService $authenticationService ) {
		$this->authenticationService = $authenticationService;
	}

	public function run() {
		$authenticated = $this->authenticationService->isAuthenticated(33);
		printf("is authenticated: %s\n", var_export($authenticated, true));
	}

}

class YetAnotherAuthenticationClient {
	public function run() {
		return (new AuthenticationService())->isAuthenticated(100);
	}
}

$client = new AuthenticationClient(new AuthenticationService());
$client->run();