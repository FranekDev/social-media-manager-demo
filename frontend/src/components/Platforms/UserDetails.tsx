'use client';

import { Skeleton } from '../ui/skeleton';
import { cn } from '@/lib/utils';
import useUserDetails from '@/lib/hooks/useUserDetails';

export default function UserDetails({ className }: { className: string }) {
  const userDetails = useUserDetails();

  if (!userDetails) {
    return (
      <div className={cn('flex flex-col items-start gap-3', className)}>
        <Skeleton className="w-[200px] h-[20px]" />
        <Skeleton className="w-[200px] h-[20px]" />
        <Skeleton className="w-[200px] h-[20px]" />
      </div>
    );
  }

  return (
    <div className={cn('flex flex-col gap-3', className)}>
      <p>Username: {userDetails.userName}</p>
      <p>Followers: {userDetails.followers_count}</p>
      <p>Posts: {userDetails.media_count}</p>
    </div>
  );
}
