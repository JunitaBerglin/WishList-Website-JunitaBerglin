import { createFileRoute } from '@tanstack/react-router'
import { Statistics } from '../../components/pages/Statistics'

export const Route = createFileRoute('/statistics/StatisticsRoute')({
  component: Statistics,
})
