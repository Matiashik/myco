#include <iostream>
#include <string>

using namespace std;

namespace out {
    void print(string str) {
        cout << str;
    }
    void println(string str) {
        cout << str << "\n";
    }
}