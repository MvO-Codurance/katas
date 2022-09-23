<?php
declare(strict_types=1);

use ParallelChange\ShoppingCart;

require __DIR__ . '/vendor/autoload.php';

class SomeConsumer {
	public function doStuff() {
		$shoppingCart = new ShoppingCart();
		$shoppingCart->add(100);
		printf( "other consumer %d\n", $shoppingCart->calculateTotalPrice());
	}
}

$shoppingCart = new ShoppingCart();
$shoppingCart->add(10);
printf("number of products: %d\n", $shoppingCart->getNumberOfProducts());
printf("total price: %d\n", $shoppingCart->calculateTotalPrice());
printf("has discount: %s\n", var_export($shoppingCart->hasDiscount(), true));


