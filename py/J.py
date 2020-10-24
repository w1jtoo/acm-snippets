"""
usefull snippets:
    - map(int, input().split())
    - map(int, sys.stdin.readline().split()))
    - int(input())
    - int(sys.stdin.readline().strip())

    - sys.stdout.write()
    - sys.stdout.write(" ".join(map(str, c) # writes c - collection of ints
"""
# import collections
import sys
from bisect import bisect_left

# recursion increase
# sys.setrecursionlimit(10000)

# number with big precision
# from decimal
# getcontext().prec = 10_000


# longest common prefix
def get_lcp(s, suffix_array):
    s = s + "$"
    n = len(s)
    lcp = [0] * (n)
    pos = [0] * (n)
    for i in range(n - 1):
        pos[suffix_array[i]] = i
    k = 0
    for i in range(n - 1):
        if k > 0:
            k -= 1
        if pos[i] == n - 1:
            lcp[n - 1] = -1
            k = 0
            continue
        else:
            j = suffix_array[pos[i] + 1]
            while max([i + k, j + k]) < n and s[i + k] == s[j + k]:
                k += 1
            lcp[pos[i]] = k

    return lcp


def get_suffix_array(word):
    suffix_array = [("", len(word))]

    for position in range(len(word)):
        sliced = word[len(word) - position - 1 :]
        suffix_array.append((sliced, len(word) - position - 1))

    suffix_array.sort(key=lambda x: x[0])
    return [item[1] for item in suffix_array]


def get_ints():
    return map(int, sys.stdin.readline().strip().split())


def bin_search(collection, element):
    i = bisect_left(collection, element)
    if i != len(collection) and collection[i] == element:
        return i
    else:
        return -1


def main():
    pass


if __name__ == "__main__":
    main()
