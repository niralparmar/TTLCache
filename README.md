# TTLCache
I have been ask to implement TTL cache as part of phone interview. I had roughly 30 mins to finish. 

### Problem Statement:
Implement TTL Cache

### Questions:
1. how to set cache expiry?
A. Pass the expiration value while creating a root cache object.
2. Is these API looks correct? Get,Add(key,value),Count
A. Yes. Count should return only non-expired cache items.
3. How add flow should work?
A. Add cache item if its not exist. If item exist than Update the creation date to current.
4. How get flow should work?
A. while getting the item, check if item is not expired and return it. If item is expired than remove the item from cache and return NULL.

### Assuption:
Cache duration is in days.
cache value is string

## I will appreciate any feedback.
