# Tuples - immutable data type
# There is no way to update/change/add/remove an item from a tuple
tup1 = (1, 2, 3, 4, 5, [100, 100])
# tup1[0] = 1000000 - error

converted_tup1 = list(tup1)
converted_tup1[0] = 1000000
tup1 = tuple(converted_tup1)
#print(tup1)

# Advantages:
# Tuples are much faster than a Python List


# Dictionaries #
"""
1. Dictionary is an unordered collection of data (no index)
2. It is iterable
3. It holds data pieces in the form of Key-Value Pair
4. A "key" can be anything but not a collection (string, integer)
"""

Dict1 = {
    1 : "Argentina",
    2 : ["Brazil", "Germany"],
    "Key3" : 1000,
}

print(Dict1.keys())
print(Dict1.values())
print(len(Dict1))

# Access of value by its key
print(Dict1[1])
print(Dict1["Key3"])















