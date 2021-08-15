# Uses python3

def pisanoPeriod(m): 
    previous, current = 0, 1
    for i in range(0, m * m): 
        previous, current= current, (previous + current) % m 
          
        # A Pisano Period starts with 01 
        if (previous == 0 and current == 1): 
            return i + 1

def calc_fib(n):
    if(n==0):
        return 0
    myarray=[0] * (n+1)
    myarray[0]=0
    myarray[1]=1
    for i in range(2,n+1):
        myarray[i]=(myarray[i-1]+myarray[i-2])
    return myarray[n]
# Calculate Fn mod m  
def fibonacciModulo(n, m): 
      
    # Getting the period 
    pisano_period = pisanoPeriod(m) 
      
    # Taking mod of N with  
    # period length 
    n = n % pisano_period 
    if n==0: 
        return 0
    elif n==1: 
        return 1
    return (calc_fib(n) % m) 

toks=input().split()
a=int(toks[0])
b=int(toks[1])
print(fibonacciModulo(a, b))
