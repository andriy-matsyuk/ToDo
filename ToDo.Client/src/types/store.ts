import { Todo } from './todo';

export interface TodoState {
    selectedTodo: Todo | null;
    filters: {
        searchTerm: string;
        priorityFilter: number | null;
        showCompleted: boolean;
    };
}