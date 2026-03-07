import React from 'react';
import { Typography, Paper } from '@mui/material';

const GoalsPage: React.FC = () => {
  return (
    <Paper sx={{ p: 3 }}>
      <Typography variant="h4" gutterBottom>
        Задачи
      </Typography>
      <Typography variant="body1">
        Здесь будет список ваших задач
      </Typography>
    </Paper>
  );
};

export default GoalsPage;