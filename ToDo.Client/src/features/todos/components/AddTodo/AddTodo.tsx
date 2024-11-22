import { useState } from 'react';
import { Input } from '@/components/ui/input';
import { Button } from '@/components/ui/button';
import { Plus } from 'lucide-react';
import { Priority } from '@/types/todo';
import { Textarea } from '@/components/ui/textarea';
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from '@/components/ui/select';
interface AddTodoProps {
    onAdd: (title: string, description: string, priority: Priority) => void;
}

export const AddTodo = ({ onAdd }: AddTodoProps) => {
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [priority, setPriority] = useState<Priority>(Priority.Low);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (title.trim()) {
            onAdd(title, description, priority);
            setTitle('');
            setDescription('');
            setPriority(Priority.Low);
        }
    };

    return (
        <form onSubmit={handleSubmit} className="space-y-4">
            <div className="flex gap-4">
                <div className="flex-1">
                    <Input
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        placeholder="Todo title..."
                        className="mb-2"
                    />
                    <Textarea
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        placeholder="Add description..."
                        className="h-20"
                    />
                </div>
                <div className="space-y-2">
                    <Select
                        value={priority.toString()}
                        onValueChange={(val) => setPriority(Number(val) as Priority)}
                    >
                        <SelectTrigger className="w-32">
                            <SelectValue placeholder="Priority" />
                        </SelectTrigger>
                        <SelectContent>
                            <SelectItem value={Priority.Low.toString()}>Low</SelectItem>
                            <SelectItem value={Priority.Medium.toString()}>Medium</SelectItem>
                            <SelectItem value={Priority.High.toString()}>High</SelectItem>
                            <SelectItem value={Priority.Critical.toString()}>Critical</SelectItem>
                        </SelectContent>
                    </Select>
                    <Button type="submit" className="w-full">
                        <Plus className="h-4 w-4 mr-2" />
                        Add Todo
                    </Button>
                </div>
            </div>
        </form>
    );
};