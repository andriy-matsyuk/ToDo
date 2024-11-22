import { Todo } from '@/types/todo';
import { TodoItem } from '../TodoItem/TodoItem';
import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card';

interface TodoListProps {
    title: string;
    todos: Todo[];
    onTodoComplete: (id: string) => void;
    onTodoDelete: (id: string) => void;
}

export const TodoList = ({
    title,
    todos,
    onTodoComplete,
    onTodoDelete
}: TodoListProps) => {
    return (
        <Card>
            <CardHeader>
                <CardTitle>{title}</CardTitle>
            </CardHeader>
            <CardContent>
                <div className="space-y-4">
                    {todos.map((todo) => (
                        <TodoItem
                            key={todo.id}
                            todo={todo}
                            onComplete={onTodoComplete}
                            onDelete={onTodoDelete}
                        />
                    ))}
                </div>
            </CardContent>
        </Card>
    );
};