#include <iostream>

int main() {
	for(int a = 0; a < 2; a++) {
		for(int b = 0; b < 2; b++) {
			for(int c = 0; c < 2; c++) {
				for(int d = 0; d < 2; d++) {
					printf("%d\n", ((a | b) & (c | d)) == ((a&c)|(b&c)|(a&d)|(b&d)));
				}
			}
		}
	}
}
