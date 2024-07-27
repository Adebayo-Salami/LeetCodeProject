#pragma once

template<typename K, typename V>
class Pair
{
public:
	Pair(K key, V value);
	K GetKey() const;
	V GetValue() const;

private:
	K key;
	V value;

};

template<typename K, typename V>
Pair<K, V>::Pair(K key, V value) :key(key), value(value) {};

template<typename K, typename V>
K Pair<K, V>::GetKey() const {
	return key;
}

template<typename K, typename V>
V Pair<K, V>::GetValue() const {
	return value;
}