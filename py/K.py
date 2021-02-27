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


# input parser
# n, d, li, ld, ls, s - int, float, list of ints, list of floats, list of string, string
# lists are lines with ' '(space) delimiters
def get_from_input(format: str, wrap_lists=True):
    result = []
    selected_types = format.split()
    for type in selected_types:
        input = sys.stdin.readline().strip()
        if type == 'n':
            result.append(int(input))
        elif type == 'd':
            result.append(float(input))
        elif type == 's':
            result.append(input)
        elif type == 'li':
            mapped = map(int, input.split())
            result.append(list(mapped) if wrap_lists else mapped)
        elif type == 'ld':
            mapped = map(float, input.split())
            result.append(list(mapped) if wrap_lists else mapped)
        elif type == 'ls':
            result.append(list(input.split()))

    if len(result) == 1:
        return result[0]
    return result


# splits aaasfffsga into (aaa, s, fff, s, g, a) blocks with signature (startPos, length, type)
def split_into_blocks(s):
    blocks = []

    i = 0
    curr_type = s[0]
    curr_len = 0
    while i < len(s):
        if s[i] == curr_type:
            curr_len += 1
            i += 1
        else:
            blocks.append((i - curr_len, curr_len, curr_type))
            curr_type = s[i]
            curr_len = 0

    blocks.append((i - curr_len, curr_len, curr_type))

    return blocks


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
        sliced = word[len(word) - position - 1:]
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
