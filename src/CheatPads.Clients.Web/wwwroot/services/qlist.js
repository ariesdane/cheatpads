define(["ko"], function (ko) {

    var arrayQuery;

	_arrayElementCompare = function (element) {
	    return function (other) {
	        return element === other;
	    };
	},

	_firstIndex = function (array, predicate, increments, startIndex, count) {
	    var thisElement,
			thisLength = array.length,
			fnPredicate = _predicate(predicate);

	    increments = increments || 1;

	    if (_isUndefined(startIndex)) {
	        startIndex = increments > 0 ? 0 : thisLength - 1;
	    }

	    if (_isUndefined(count) || count > thisLength) {
	        count = thisLength;
	    }

	    while (count > 0) {
	        thisElement = array[startIndex];
	        if (fnPredicate(thisElement)) {
	            return startIndex;
	        }
	        startIndex += increments;
	        count--;
	    }
	    return -1;
	},

	_getTop1 = function (comparison, array, selector) {
	    var thisElement,
			useSelector = _isFunction(selector),
			elementToCheckAgainst;

	    for (var i = 0, thisLength = array.length, extreme = thisLength > 0 ? array[0] : null; i < thisLength; i++) {
	        thisElement = array[i];
	        elementToCheckAgainst = (useSelector ? selector(thisElement) : thisElement);
	        if (comparison ?
				elementToCheckAgainst <= extreme :
				elementToCheckAgainst >= extreme
			) {
	            extreme = thisElement;
	        }
	    }
	    return extreme;
	},

    _identity = function (obj) {
        return obj;
    },

	_isArray = function (obj) {
	    return obj.constructor === Array;
	},

	_isFunction = function (obj) {
	    return typeof obj == "function";
	},

	_isObject = function (obj) {
	    return typeof obj === "object" && obj != null;
	},

	_isDate = function (obj) {
	    return obj && obj.constructor === Date;
	},

	_isUndefined = function (obj) {
	    return obj === undefined;
	},

	_indexOf = function (array, element, start) {
	    return _firstIndex(this, _arrayElementCompare(element), 1, start);
	},

	_joinXY = function (innerElement, outerElement) {
	    return {
	        inner: innerElement,
	        outer: outerElement
	    };
	},

	_lastIndexOf = function (array, element, start) {
	    return _firstIndex(array, _arrayElementCompare(element), -1, start);
	},

	_loop = function (array, callback, condition, returnOn) {
	    for (var i = 0; i < array.length && condition(array[i], i) != returnOn; i++) {
	        callback(array[i], i);
	    }
	},

	_minitabVariation = function (q, n) {
	    return 1 / 4 * (q * n + q);
	},

	_multiply = function (runningTotal, value) {
	    return runningTotal * value;
	},

	_partition = function (array, keySelector, elementSelector, resultSelector) {
	    var i = 0,
			thisElement,
			partitions = [],
			p,
			useElementSelector = _isFunction(elementSelector),
			useResultSelector = _isFunction(resultSelector);

	    while (i < array.length) {
	        thisElement = array[i++];
	        p = keySelector(thisElement);
	        if (useElementSelector) {
	            thisElement = elementSelector(thisElement);
	        }

	        (partitions[p] = (p in partitions) ? partitions[p] : []).push(thisElement);
	    }

	    if (useResultSelector) {
	        _useResultSelectorOnGroup(partitions, resultSelector);
	    }

	    return partitions;
	},

	_predicate = function (predicate) {
	    return _isFunction(predicate)
			? predicate
			: _isObject(predicate)
				? function (item, target) {
				    for (var key in predicate) {
				        var val = target ? target[key] : predicate[key];
				        if (_isDate(item[key])) {
				            if (+item[key] !== +val) return false;
				        }
				        else if (item[key] !== val) return false;
				    }
				    return true;
				}
				: function (val) {
				    return val === predicate;
				};
	},

	_randomForSorting = function () {
	    return Math.random() - 0.5;
	},

	_selector = function (selector) {
	    if (typeof selector == "string") {
	        return _selectorForString(selector);
	    }
	    else if (_isUndefined(selector)) {
	        return _identity;
	    }
	    return selector;
	},

    _selectorForString = function (keyString) {
        var keys = keyString.split("."), n = keys.length;
        return function (item) {
            var i = -1;
            while (++i < n && _isObject(item)) item = item[keys[i]];
            return i === n ? item : void 0;
        }
    },

	_sort = function (array, field, order) {
	    var sorter = function (f, m) {
	        return function (a, b) { a[f] > b[f] ? 1 * m : -1 * m; }
	    };
	    array.sort(field, order || 1);
	},

	_total = function (array, aggregator, selector) {
	    var value, total = null,
			i = array.length - 1,
			selector = _selector(selector);

	    while (i >= 0) {
	        value = selector(array[i--]);
	        total = total === null ? value : aggregator(total, value);
	    }
	    return total;
	},

	_unwrap = function (list) {
	    return list._ || list;
	},

	_useResultSelectorOnGroup = function (array, resultSelector) {
	    var key,
			thisElement;

	    for (key in array) {
	        thisElement = array[key];
	        array[key] = resultSelector(thisElement, key);
	    }

	    return array;
	},

	_wrap = function (array) {
	    return _isObject(array) && array._ ? array : new arrayQuery(array);
	};

	arrayQuery = function(array) {
	    var _ = typeof array === "string"
            ? JSON.parse(array)
            : ko.unwrap(array) || [];

	    var q = {
	        $data: {
	            get: function () { return _; }
	        },
	        all: function (predicate) {
	            var all = true,
                    i = 0;

	            while (i < _.length) {
	                all &= predicate(_[i++]);
	            }
	            return all ? true : false;
	        },

	        any: function (predicate) {
	            return _firstIndex(_, predicate) >= 0;
	        },

	        average: function (selector) {
	            var thisLength = _.length;
	            return thisLength ? this.sum(selector) / thisLength : 0;
	        },

	        clone: function () {
	            return _wrap(_.concat());
	        },

	        concat: function () {
	            return _wrap(Array.prototype.concat.apply(_, arguments));
	        },

	        contains: function (item) {
	            return _.indexOf(item) > -1;
	        },

	        count: function () {
	            var arg = arguments[0], count = 0, predicate;
	            if (!arguments.length) {
	                return _isArray(_) ? _.length : 0;
	            }
	            predicate = _isFunction(arg) ? arg : function (item) {
	                return item === arg;
	            };
	            _.forEach(function (item) {
	                count += predicate(item) ? 1 : 0;
	            });
	            return count;
	        },
	       
	        distinct: function (selector) {
	            var distinct = [], data = _, x, y;

	            data.forEach(function (x) {
	                y = _selector(selector)(x);
	                if (distinct.indexOf(y) == -1) {
	                    distinct.push(y);
	                }
	            });

	            return _wrap(distinct);
	        },

	        each: function (callback) {
	            var i = -1;
	            while (++i < _.length) {
	                callback.call(_[i], _[i], i);
	            }
	            return this;
	        },

	        empty: function () {
	            _.splice(0, _.length);
	        },

	        first: function (predicate) {
	            var firstIndex = _firstIndex(_, predicate);
	            if (firstIndex >= 0) {
	                return _[firstIndex];
	            }
	            return undefined;
	        },

	        flatten: function () {
	            var i = 0,
                    flattened = _wrap([]),
                    thisElement;

	            while (i < _.length) {
	                thisElement = _[i++];
	                arrayQuery.prototype.push.apply(
                        flattened, _isArray(thisElement) ?
	                    thisElement :
                        [thisElement]
                    );
	            }
	            return flattened;
	        },

	        get: function (index) {
	            return index === undefined
                    ? _unwrap(this)
                    : index < _.length
                    ? _[index]
                    : undefined;
	        },

	        getRandom: function () {
	            return _[Math.floor(Math.random() * _.length)];
	        },

	        groupBy: function (keySelector, elementSelector, resultSelector) {
	            var partition = _partition(_,
                    keySelector,
                    elementSelector,
                    resultSelector),
                    key;
	            _.splice(0, _.length);

	            for (key in partition) {
	                _[key] = partition[key];
	            }
	            return this;
	        },

	        indexOf: function (predicate, startIndex, count) {
	            return _isFunction(predicate)
                    ? _firstIndex(_, predicate, 1, startIndex, count)
                    : _indexOf(_, arguments);
	        },

	        innerJoin: function (other, predicate, joinedObjectCreator) {
	            other = _unwrap(other);
	            predicate = _predicate(predicate);
	            if (!_isArray(other)) {
	                return this.clone();
	            }
	            if (!_isFunction(joinedObjectCreator)) {
	                joinedObjectCreator = _joinXY;
	            }

	            var joined = [],
                innerElement,
                outerElement,
                i = 0,
                j;

	            while (i < _.length) {
	                innerElement = _[i++];
	                j = 0;
	                while (j < other.length) {
	                    outerElement = other[j++];
	                    if (predicate(innerElement, outerElement)) {
	                        joined.push(joinedObjectCreator(innerElement, outerElement));
	                    }
	                }
	            }
	            return _wrap(joined);
	        },

	        insert: function (index, element) {
	            _.splice(index, 0, element);
	        },

	        insertRange: function (index, elements) {
	            Array.prototype.splice.apply(_,
                    [index, 0].concat(
                        arguments.length < 3 ?
                        _unwrap(elements) :
                        Array.prototype.slice.call(arguments, 1)
                    )
                );
	        },

	        join: function () {
	            return Array.prototype.join.apply(_, arguments);
	        },

	        last: function (predicate) {
	            var firstIndex = _firstIndex(_, predicate, -1);
	            if (firstIndex >= 0) {
	                return _[firstIndex];
	            }
	            return undefined;
	        },

	        lastIndexOf: function (predicate, startIndex, count) {
	            return _isFunction(predicate)
                    ? _firstIndex(_, predicate, -1, startIndex, count)
                    : _lastIndexOf(_, predicate, startIndex);
	        },

	        map: function (selector) {
	            if (_isFunction(selector)) {
	                var results = [];
	                this.each(function (e, i) {
	                    results.push(selector(e, i));
	                });
	                return _wrap(results);
	            }
	            return void 0;
	        },

	        max: function (selector) {
	            return _getTop1(0, _, selector);
	        },

	        median: function (/*selector*/) {
	            var middleFloor,
                    middleCeil,
                    sorted;

	            sorted = this.clone();
	            _sortAndThenSortMore(_unwrap(sorted), arguments);
	            middleFloor = sorted.middle();
	            middleCeil = sorted.middle(1);

	            return middleFloor < middleCeil ?
                        ((middleFloor + middleCeil) / 2) :
                        middleFloor;
	        },

	        min: function (selector) {
	            return _getTop1(1, _, selector);
	        },

	        mode: function (selector) {
	            var highestCount = 0,
                    highestElements = [],
                    lastElement,
                    currentCount,
                    selection,
                    i = 0,
                    element;

	            selection = _unwrap((_isFunction(selector) ? this.map(selector) : this.clone())
                .ascending());

	            while (i < selection.length) {
	                element = selection[i++];
	                currentCount = (element === lastElement ? currentCount + 1 : 0);
	                if (currentCount === highestCount) {
	                    highestElements.push(element);
	                } else if (currentCount > highestCount) {
	                    highestElements = [element];
	                    highestCount++;
	                }
	                lastElement = element;
	            }

	            return highestElements;
	        },

	        multiply: function (selector) {
	            return _.length > 0 ? _total(_, _multiply, selector) : 0;
	        },

	        outerJoin: function (other, predicate, joinedObjectCreator) {
	            var joined = [],
                    innerElement,
                    outerElement,
                    outerNotFound,
                    i = 0,
                    j,
                    usePredicate = _isFunction(predicate);

	            other = _unwrap(other);
	            if (!_isArray(other)) {
	                return this.clone();
	            }
	            if (!_isFunction(joinedObjectCreator)) {
	                joinedObjectCreator = _joinXY;
	            }

	            while (i < _.length) {
	                innerElement = _[i++];
	                outerNotFound = 1;
	                j = 0;
	                while (j < other.length) {
	                    outerElement = other[j++];
	                    if (usePredicate && predicate(innerElement, outerElement) ||
                            !usePredicate && innerElement === outerElement
                        ) {
	                        outerNotFound = 0;
	                        joined.push(joinedObjectCreator(innerElement, outerElement));
	                    }
	                }

	                if (outerNotFound) {
	                    joined.push(joinedObjectCreator(innerElement, null));
	                }
	            }
	            return _wrap(joined);
	        },

	        pack: function () {
	            var i = _.length - 1,
                    thisElement;
	            while (i >= 0) {
	                thisElement = _[i];
	                if (_isUndefined(thisElement) || thisElement === null) {
	                    _.splice(i, 1);
	                }
	                i--;
	            }
	            return this;
	        },

	        partition: function (keySelector, elementSelector, resultSelector) {
	            return _wrap(_partition(_, keySelector, elementSelector, resultSelector));
	        },

	        pluck: function (field) {
	            return this.map(function (e) {
	                return e[field];
	            });
	        },

	        pop: function () {
	            return Array.prototype.pop.apply(_, arguments);
	        },

	        push: function () {
	            return Array.prototype.push.apply(_, arguments);
	        },

	        remove: function (item) {
	            if (!typeof item === number) {
	                item = _.indexOf(item);
	            }
	            _.splice(item, 1);
	        },

	        removeRange: function (start, count) {
	            _.splice(start, count);
	        },

	        removeWhere: function (predicate) {
	            var i = _.length - 1,
                    removed = [];

	            while (i >= 0) {
	                if (_predicate(predicate)(_[i])) {
	                    removed.push(_.splice(i, 1)[0]);
	                }
	                i--;
	            }
	            return removed.length ? removed : undefined;
	        },

	        reverse: function () {
	            return _wrap(Array.prototype.reverse.apply(_, arguments));
	        },

	        select: function (selector) {
	            return this.map(_selector(selector));
	        },

	        selectMany: function (selector) {
	            var list = this.select(selector),
                    results = [];

	            if (list && list.count()) {
	                list.each(function (entries) {
	                    results = results.concat(entries || []);
	                });
	            }
	            return _wrap(results);
	        },

	        shift: function () {
	            return Array.prototype.shift.apply(_, arguments);
	        },

	        shuffle: function () {
	            _.sort(_randomForSorting);
	            return this;
	        },

	        slice: function (startBefore, endBefore) {
	            return _wrap(_.slice(startBefore, endBefore));
	        },

	        single: function (predicate) {
	            var matches = _unwrap(_wrap(this).where(predicate));

	            if (matches && matches.length != 1) {
	                throw new Error("Operation 'single' produced zero or multiple results.");
	            }
	            return matches[0];
	        },

	        skip: function (count) {
	            return _wrap(_.slice(count));
	        },

	        sort: function (field, direction) {
	            if (_isFunction(field)) {
	                Array.prototype.sort.apply(_, field);
	            }
	            else {
	                _sort(_, field, { "+": 1, "-": -1, asc: 1, desc: -1 }[direction]);
	            }
	            return this;
	        },

	        sortDesc: function (field) {
	            return this.sort(field, "-")
	        },

	        sum: function (selector) {
	            return _.length > 0 ? _total(_, function (runningTotal, value) {
	                return runningTotal + value;
	            }, selector) : 0;
	        },

	        take: function (count) {
	            return _wrap(_.slice(0, count));
	        },

	        toString: function () {
	            return _.toString();
	        },

	        unshift: function () {
	            return Array.prototype.unshift.apply(_, arguments);
	        },

	        update: function (keyvals) {
	            this.each(function (e) {
	                for (var k in keyvals) {
	                    e[k] = keyvals[k];
	                }
	            });
	            return this;
	        },

	        valueOf: function () {
	            return Array.prototype.valueOf.apply(_, arguments);
	        },

	        where: function (predicate) {
	            var fnPredicate = _predicate(predicate),
                    matches = [],
                    thisElement,
                    i = 0;

	            while (i < _.length) {
	                thisElement = _[i++];
	                if (fnPredicate(thisElement)) {
	                    matches.push(thisElement);
	                }
	            }
	            return _wrap(matches);
	        },

	        not: function (predicate) {
	            return this.where(function (item) {
	                return !_predicate(predicate)(item);
	            });
	        }
	    };

	    q.exists = q.any;

	    Object.defineProperties(q, {
	        length: {
	            get: function () { return _.length; }
	        },
	        result: {
	            get: function () { return _ || [];  }
	        }
	    });

	    return q;
	}

	return arrayQuery;
});