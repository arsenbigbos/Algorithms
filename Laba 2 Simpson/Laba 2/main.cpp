#include <iostream>
#include <cmath>

using namespace std;

double f(double x) {
	//return (cos(2 * x)) / (1 + (1 * x) + (1.3 * x * x * x));
	return (4 * x * x * x);
}

double Sympson(double a, double b, int n) {
	double h = (b - a) / n;
	double sum = f(a) + f(b);
	int k;
	for (int i = 1; i <= n - 1; i++) {
		k = 2 + 2 * (i % 2);
		sum += k * f(a + i * h);
	}
	sum *= h / 3;
	return sum;
}
int main() {
	double a, b;
	int n;
	a = 0;
	b = 4;
	n = 100;
	double eps = 0.0001;
	cout << "Sympson " << Sympson(a, b, n) << endl;
	int k = 10;
	int i = 0;
	double diff;
	do {
		i++;
		diff = (1 / 15) * (fabs(Sympson(a, b, k * i) - Sympson(a, b, k * (i + 1))));

	} while (diff > eps);
	cout << "k= " << k * (i + 1) << " " << "Sympson " << Sympson(a, b, k * (i + 1));
	return 0;
}