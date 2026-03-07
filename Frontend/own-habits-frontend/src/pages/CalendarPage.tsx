import React from 'react';
import { Typography, Paper } from '@mui/material';

const CalendarPage: React.FC = () => {
  return (
    <Paper sx={{ p: 3 }}>
      <Typography variant="h4" gutterBottom>
        Профиль
      </Typography>
      <Typography variant="body1">
        Здесь будет ваш профиль
      </Typography>
    </Paper>
  );
};

export default CalendarPage;