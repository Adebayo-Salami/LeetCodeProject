#pragma once
#include <map>

template<typename K, typename V>
class interval_map {
	friend void IntervalMapTest();
	V m_valBegin;
	std::map<K, V> m_map;
public:
	interval_map(V const& val)
		: m_valBegin(val)
	{}

	void assign(K const& keyBegin, K const& keyEnd, V const& val) {
		if (!(keyBegin < keyEnd))
			return;

		auto itBegin = m_map.lower_bound(keyBegin);
		auto itEnd = m_map.lower_bound(keyEnd);

		if (m_map.empty()) {
			m_map.emplace(keyBegin, val);
			m_map.emplace(keyEnd, m_valBegin);
		}
		else {
			if (itEnd->first > keyEnd) {
				auto prev = std::prev(itEnd);
				m_map.emplace(keyEnd, prev->second);
			}
			m_map.emplace(keyBegin, val);
			auto itBegin = m_map.lower_bound(keyBegin);
			itEnd = m_map.lower_bound(keyEnd);
			m_map.erase(std::next(itBegin), itEnd);
		}




		//auto itBegin = m_map.lower_bound(keyBegin);
		//auto itEnd = m_map.lower_bound(keyEnd);

		//if (itBegin == m_map.end() || itBegin->first != keyBegin) {
		//	if (itBegin != m_map.begin()) {
		//		auto prev = std::prev(itBegin);
		//		if (prev->second != val) {
		//			itBegin = m_map.emplace_hint(itBegin, keyBegin, prev->second);
		//		}
		//	}
		//	else {
		//		if (m_valBegin != val) {
		//			itBegin = m_map.emplace_hint(itBegin, keyBegin, m_valBegin);
		//		}
		//	}
		//}

		//if (itEnd == m_map.end() || itEnd->first != keyEnd) {
		//	if (itEnd != m_map.begin()) {
		//		auto prev = std::prev(itEnd);
		//		if (prev->second != val) {
		//			itEnd = m_map.emplace_hint(itEnd, keyEnd, prev->second);
		//		}
		//	}
		//	else {
		//		if (m_valBegin != val) {
		//			itEnd = m_map.emplace_hint(itEnd, keyEnd, m_valBegin);
		//		}
		//	}
		//}

		//m_map.erase(std::next(itBegin), itEnd);

		//itBegin->second = val;
		//auto it = itBegin;
		//while (it != m_map.end()) {
		//	auto next = std::next(it);
		//	if (next != m_map.end() && next->second == it->second) {
		//		m_map.erase(next);
		//	}
		//	else {
		//		it = next;
		//	}
		//}
	}

	V const& operator[](K const& key) const {
		auto it = m_map.upper_bound(key);
		if (it == m_map.begin()) {
			return m_valBegin;
		}
		else {
			return (--it)->second;
		}
	}
};

// Many solutions we receive are incorrect. Consider using a randomized test
// to discover the cases that your implementation does not handle correctly.
// We recommend to implement a test function that tests the functionality of
// the interval_map, for example using a map of int intervals to char.