import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'groupBy' })
export class GroupByPipe implements PipeTransform {
    transform(collection: Array<any>, property: string): Array<any> {
        // Return null, if array is empty
        if (!collection) {
            return null;
        }

        //Create tree with one level, where roots will be groups
        const groupedCollection = collection.reduce((previous, current) => {
            if (!previous[current[property]]) {
                previous[current[property]] = [current];
            } else {
                previous[current[property]].push(current);
            }

            return previous;
        }, {});

        // возвращаем массив объектов, каждый объект содержит группу исходных объектов
        // return array object, each object contains group of original objects
        return Object.keys(groupedCollection).map(key => ({ key, value: groupedCollection[key] }));
    }
}