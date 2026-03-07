import React from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  TextField,
  Grid,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  FormControlLabel,
  Switch,
  Box,
  type SelectChangeEvent
} from '@mui/material';
import type { Priority, Difficulty } from '../../types/Goal';

export interface NewGoalData {
  title: string;
  description: string;
  deadline: string;
  priority: 'Low' | 'Normal' | 'High' | 'Urgent';
  difficulty: 'Easy' | 'Medium' | 'Hard' | 'Extreme';
  repeatability: boolean;
}

interface AddGoalDialogProps {
  open: boolean;
  onClose: () => void;
  onSubmit: (goalData: NewGoalData) => void;
}

const AddGoalDialog: React.FC<AddGoalDialogProps> = ({ open, onClose, onSubmit }) => {
  const [newGoal, setNewGoal] = React.useState({
    title: '',
    description: '',
    deadline: '',
    priority: 'Normal' as Priority,
    difficulty: 'Easy' as Difficulty,
    repeatability: false
  });

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setNewGoal(prev => ({ ...prev, [name]: value }));
  };

  const handleSelectChange = (e: SelectChangeEvent) => {
    const { name, value } = e.target;
    setNewGoal(prev => ({ ...prev, [name]: value }));
  };

  const handleSwitchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setNewGoal(prev => ({ ...prev, repeatability: e.target.checked }));
  };

  const handleSubmit = () => {
    onSubmit(newGoal);
    setNewGoal({
      title: '',
      description: '',
      deadline: '',
      priority: 'Normal',
      difficulty: 'Easy',
      repeatability: false
    });
    onClose();
  };

  return (
    <Dialog open={open} onClose={onClose} maxWidth="md" fullWidth>
      <DialogTitle>Создание новой цели</DialogTitle>
      <DialogContent>
        <Box sx={{ pt: 2, display: 'flex', flexDirection: 'column', gap: 2 }}>
          <TextField
            name="title"
            label="Название цели"
            value={newGoal.title}
            onChange={handleInputChange}
            fullWidth
            required
          />
          <TextField
            name="description"
            label="Описание"
            value={newGoal.description}
            onChange={handleInputChange}
            fullWidth
            multiline
            rows={3}
          />
          
          <Grid container spacing={2}>
            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField
                name="deadline"
                type="datetime-local"
                label="Дедлайн"
                value={newGoal.deadline}
                onChange={handleInputChange}
                fullWidth
                InputLabelProps={{ shrink: true }}
              />
            </Grid>
            
            <Grid size={{ xs: 12, sm: 6 }}>
              <FormControl fullWidth>
                <InputLabel>Приоритет</InputLabel>
                <Select
                  name="priority"
                  value={newGoal.priority}
                  label="Приоритет"
                  onChange={handleSelectChange}
                >
                  <MenuItem value="Low">Низкий</MenuItem>
                  <MenuItem value="Normal">Средний</MenuItem>
                  <MenuItem value="High">Высокий</MenuItem>
                  <MenuItem value="Urgent">Срочный</MenuItem>
                </Select>
              </FormControl>
            </Grid>
            
            <Grid size={{ xs: 12, sm: 6 }}>
              <FormControl fullWidth>
                <InputLabel>Сложность</InputLabel>
                <Select
                  name="difficulty"
                  value={newGoal.difficulty}
                  label="Сложность"
                  onChange={handleSelectChange}
                >
                  <MenuItem value="Easy">Легко</MenuItem>
                  <MenuItem value="Medium">Средне</MenuItem>
                  <MenuItem value="Hard">Сложно</MenuItem>
                  <MenuItem value="Extreme">Экстремально</MenuItem>
                </Select>
              </FormControl>
            </Grid>
            
            <Grid size={{ xs: 12, sm: 6 }}>
              <FormControlLabel
                control={
                  <Switch
                    checked={newGoal.repeatability}
                    onChange={handleSwitchChange}
                  />
                }
                label="Повторяющаяся"
              />
            </Grid>
          </Grid>
        </Box>
      </DialogContent>
      <DialogActions>
        <Button onClick={onClose}>Отмена</Button>
        <Button variant="contained" onClick={handleSubmit}>Создать</Button>
      </DialogActions>
    </Dialog>
  );
};

export default AddGoalDialog;