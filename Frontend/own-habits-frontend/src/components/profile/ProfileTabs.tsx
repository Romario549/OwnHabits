import React from 'react';
import { Box, Tab, Tabs } from '@mui/material';

interface ProfileTabsProps {
  value: number;
  onChange: (event: React.SyntheticEvent, newValue: number) => void;
  counts: {
    goals: number;
    skills: number;
    characteristics: number;
  };
}

const ProfileTabs: React.FC<ProfileTabsProps> = ({ value, onChange, counts }) => {
  return (
    <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
      <Tabs value={value} onChange={onChange} variant="scrollable" scrollButtons="auto">
        <Tab label={`Цели (${counts.goals})`} />
        <Tab label={`Навыки (${counts.skills})`} />
        <Tab label={`Характеристики (${counts.characteristics})`} />
      </Tabs>
    </Box>
  );
};

export default ProfileTabs;