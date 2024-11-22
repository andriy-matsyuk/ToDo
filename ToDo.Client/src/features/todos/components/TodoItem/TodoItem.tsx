import { Priority, Todo } from '@/types/todo';
import { Checkbox } from '@/components/ui/checkbox';
import { Button } from '@/components/ui/button';
import { Trash2 } from 'lucide-react';
import { Badge } from '@/components/ui/badge';

interface TodoItemProps {
    todo: Todo;
    onComplete: (id: string) => void;
    onDelete: (id: string) => void;
}
const getPriorityBadge = (priority: Priority) => {
    const variants = {
        [Priority.Low]: "bg-green-100 text-green-800",
        [Priority.Medium]: "bg-yellow-100 text-yellow-800",
        [Priority.High]: "bg-red-100 text-red-800",
        [Priority.Critical]: "bg-purple-300 text-purple-800"
    };

    const labels = {
        [Priority.Low]: "Low",
        [Priority.Medium]: "Medium",
        [Priority.High]: "High",
        [Priority.Critical]: "Critical"
    };

    return (
        <Badge variant="outline" className={variants[priority]}>
            {labels[priority]}
        </Badge>
    );
};

export const TodoItem = ({ todo, onComplete, onDelete }: TodoItemProps) => {
    return (
        <div className="flex flex-col gap-2 p-4 border rounded-lg">
            <div className="flex items-center justify-between">
                <div className="flex items-center gap-3">
                    <Checkbox
                        checked={todo.isCompleted}
                        onCheckedChange={() => onComplete(todo.id)}
                    />
                    <div>
                        <h3 className={`font-medium ${todo.isCompleted ? 'line-through text-muted-foreground' : ''}`}>
                            {todo.title}
                        </h3>
                        <p className="text-sm text-muted-foreground">{todo.description}</p>
                    </div>
                </div>
                <div className="flex items-center gap-3">
                    {getPriorityBadge(todo.priority)}
                    <Button
                        variant="ghost"
                        size="icon"
                        onClick={() => onDelete(todo.id)}
                    >
                        <Trash2 className="h-4 w-4" />
                    </Button>
                </div>
            </div>
            <div className="flex gap-4 text-xs text-muted-foreground">
                <span>{new Date(todo.updatedAt).toLocaleDateString()}</span>
            </div>
        </div>
    );
};