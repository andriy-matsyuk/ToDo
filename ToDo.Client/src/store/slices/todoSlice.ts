import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { TodoState } from '@/types/store';
import { Todo } from '@/types/todo';

const initialState: TodoState = {
    selectedTodo: null,
    filters: {
        searchTerm: '',
        priorityFilter: null,
        showCompleted: true
    }
};

export const todoSlice = createSlice({
    name: 'todos',
    initialState,
    reducers: {
        setSelectedTodo: (state, action: PayloadAction<Todo | null>) => {
            state.selectedTodo = action.payload;
        },
        setSearchTerm: (state, action: PayloadAction<string>) => {
            state.filters.searchTerm = action.payload;
        },
        setPriorityFilter: (state, action: PayloadAction<number | null>) => {
            state.filters.priorityFilter = action.payload;
        },
        setShowCompleted: (state, action: PayloadAction<boolean>) => {
            state.filters.showCompleted = action.payload;
        }
    }
});

export const {
    setSelectedTodo,
    setSearchTerm,
    setPriorityFilter,
    setShowCompleted,
} = todoSlice.actions;