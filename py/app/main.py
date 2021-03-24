dat = [[]]

def func1():
    res = 0
    for i in range(len(dat)):
        for j in range(len(dat)):
            if i <= j - 4 and (dat[i] + dat[j])% 2 == 0:
                res += 1
    return res 

def func2():
    res = 0
    for i in range(len(dat)):
        for j in range(len(dat)):
            if i + 1 <= j <= i + 5 and dat[i] + dat[j] < 100:
                res += 1
    return res

def func31(l, n):
    a = func31(l + 1, n) if l < 11 else 0
    b = func31(l, n + 1) if n < 11 else 0
    if dat[l][n] > 100:
        return -1000
    if a > b:
        return dat[l][n] + a
    else:
        return dat[l][n] + b

def func32(l, n):
    a = func32(l + 1, n) if l < 11 else 1000
    b = func32(l, n + 1) if n < 11 else 1000
    if l == n == 11:
        return dat[l][n]
    if dat[l][n] > 100:
        return 1000
    if a < b:
        return dat[l][n] + a
    else:
        return dat[l][n] + b

def func41(l, n):
    a = func41(l + 1, n) if l < 11 else 0
    b = func41(l, n + 1) if n < 11 else 0
    if dat[l][n] < 0:
        return -1000
    if a > b:
        return dat[l][n] + a
    else:
        return dat[l][n] + b

def func42(l, n):
    a = func42(l + 1, n) if l < 11 else 1000
    b = func42(l, n + 1) if n < 11 else 1000
    if l == n == 11:
        return dat[l][n]
    if dat[l][n] < 0:
        return 1000
    if a < b:
        return dat[l][n] + a
    else:
        return dat[l][n] + b

def func51(l, n):
    a = func51(l + 1, n) if l < 11 else 0
    b = func51(l, n + 1) if n < 11 else 0
    if dat[l][n] < 0 or dat[l][n] > 100:
        return -1000
    if a > b:
        return dat[l][n] + a
    else:
        return dat[l][n] + b

def func52(l, n):
    a = func52(l + 1, n) if l < 11 else 1000
    b = func52(l, n + 1) if n < 11 else 1000
    if l == n == 11:
        return dat[l][n]
    if dat[l][n] < 0 or dat[l][n] > 100:
        return 1000
    if a < b:
        return dat[l][n] + a
    else:
        return dat[l][n] + b

def main():
    global dat
    dat = list(map(lambda x: int(x), open("One.csv").read().split(";")))
    print(func1())  
    dat = list(map(lambda x: int(x), open("Two.csv").read().split(";")))
    print(func2())
    dat = list(map(lambda x: list(map(lambda y: int(y), x.split(";"))), open("Three.csv").read().split("\n")))
    print(str(func31(0, 0)) + " " + str(func32(0, 0)))
    dat = list(map(lambda x: list(map(lambda y: int(y), x.split(";"))), open("Four.csv").read().split("\n")))
    print(str(func41(0, 0)) + " " + str(func42(0, 0)))
    dat = list(map(lambda x: list(map(lambda y: int(y), x.split(";"))), open("Five.csv").read().split("\n")))
    print(str(func51(0, 0)) + " " + str(func52(0, 0)))

main()    