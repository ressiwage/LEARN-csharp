# учебный проект по c#
цель: Необходимо на C# реализовать типизированную коллекцию  для хранения структур вида “Ключ - Значение” (по аналогии с Dictionary<K, V>). Коллекция должна реализовывать следующие функции:

1.	bool Add(K key, V value) – добавление в коллекцию пары “Ключ - Значение”. Ключ в коллекции должен быть уникальным. При добавлении ключа  должно происходить следующее:
  1.	Если элемента с таким ключом в коллекции нет, то добавляем его в коллекцию и возвращаем True;
  2.	Если элемент с таким ключом в коллекции существует, то меняем соответствующее ему значение и возвращаем False;
2.	V Remove(K key) – удаление элемента  из коллекции по ключу. Метод должен вернуть значение, соответсвтующее удаленному ключу
3.	Void Clear() – очистка коллекции
4.	K GetKeyByValue(V value) – получение первого попавшегося ключа с таким значением
5.	V GetValueByKey(K key) – получение значения по ключу
6.	bool ContainsKey(K key) – проверка на наличии элемента с введенным ключом
7.	bool ContainsValue(V value) – проверка на наличие элемента с введенным значением
8.	int Count() – возвращает количество элементов в коллекции
9.	V[] GetAllValues() – получение массива всех значений в коллекции
10.	T[] GetAllKeys() – получение массива всех ключей в коллекции
