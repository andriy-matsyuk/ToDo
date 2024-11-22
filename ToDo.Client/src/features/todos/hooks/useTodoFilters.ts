import { useMemo } from 'react';
import { useAppSelector } from '@/hooks/store/useAppSelector';
import { useAppDispatch } from '@/hooks/store/useAppDispatch';
import {
    setSearchTerm,
    setPriorityFilter,
    setShowCompleted,
} from '@/store/slices/todoSlice';
import { Todo } from '@/types/todo';

export const useTodoFilters = (todos: Todo[]) => {
    const dispatch = useAppDispatch();
    const { filters } = useAppSelector(state => state.todos);

    const filteredAndSortedTodos = useMemo(() => {
        let filtered = [...todos];

        if (filters.searchTerm) {
            filtered = filtered.filter(todo =>
                todo.title.toLowerCase().includes(filters.searchTerm.toLowerCase()) ||
                todo.description.toLowerCase().includes(filters.searchTerm.toLowerCase())
            );
        }

        if (filters.priorityFilter !== null) {
            filtered = filtered.filter(todo => todo.priority === filters.priorityFilter);
        }

        if (!filters.showCompleted) {
            filtered = filtered.filter(todo => !todo.isCompleted);
        }

        return filtered;
    }, [todos, filters]);

    return {
        filteredTodos: filteredAndSortedTodos,
        filters,
        setSearchTerm: (term: string) => dispatch(setSearchTerm(term)),
        setPriorityFilter: (priority: number | null) => dispatch(setPriorityFilter(priority)),
        setShowCompleted: (show: boolean) => dispatch(setShowCompleted(show)),
    };
};